using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.Exceptions;
using Com.Suncor.Olt.Remote.Integration;
using log4net;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class EdmontonSwipeCardService : IEdmontonSwipeCardService
    {
        private readonly ILog logger = LogManager.GetLogger(typeof (EdmontonSwipeCardService));

        private readonly IEdmontonSwipeCardReader swipeCardReader;
        private readonly IEdmontonPersonDao edmontonPersonDao;

        public EdmontonSwipeCardService() : this(new EdmontonSwipeCardReader(), DaoRegistry.GetDao<IEdmontonPersonDao>())
        {
        }

        public EdmontonSwipeCardService(IEdmontonSwipeCardReader swipeCardReader, IEdmontonPersonDao edmontonPersonDao)
        {
            this.swipeCardReader = swipeCardReader;
            this.edmontonPersonDao = edmontonPersonDao;
        }


        /// <summary>
        /// Get last swipes for Edmonton People from the past 180 days.
        /// </summary>
        public void SyncOltWithCardSwipeSystem()
        {
            List<EdmontonPerson> allInCardSwipeSystem;
            try
            {
                allInCardSwipeSystem = swipeCardReader.GetCardsFromSwipeCardSystem(180);
            }
            catch (EdmontonCardSwipeSystemReadException ex)
            {
                logger.Warn("Issue synching. Skipping Sync for today.", ex);
                return;
            }

            List<EdmontonPerson> allInOlt = edmontonPersonDao.QueryAll();
            List<EdmontonPerson> deletedInOlt = edmontonPersonDao.QueryAllDeleted();
                

            // Insert New People
            Insert(allInCardSwipeSystem, allInOlt.Union(deletedInOlt, new EdmontonPersonNameEqualityComparer()));
            
            // UndoRemove People that are now in the system again
            IEnumerable<EdmontonPerson> undeletedPeople = UndoRemove(allInCardSwipeSystem, deletedInOlt);
            
            // now that we've un-deleted them, we have to update stuff like last access and badge. So, add them to the all In Database.
            allInOlt.AddRange(undeletedPeople);

            // Update People with new badge ids or last access stuff changes
            Update(allInOlt, allInCardSwipeSystem);
            
            // Delete People no longer in badge system
            Delete(allInOlt, allInCardSwipeSystem);
        }

        public List<EdmontonPerson> QueryAll()
        {
            return edmontonPersonDao.QueryAll();
        }

        private void Delete(List<EdmontonPerson> allInOlt, List<EdmontonPerson> allInCardSwipeSystem)
        {
            HashSet<EdmontonPerson> oltPersons = new HashSet<EdmontonPerson>(allInOlt, new EdmontonPersonNameEqualityComparer());
            oltPersons.ExceptWith(allInCardSwipeSystem); // remove all items that are in the card swipe system.
            foreach (EdmontonPerson person in oltPersons)
            {
                edmontonPersonDao.Remove(person);
            }
        }

        /// <summary>
        /// Using the first name and last name only to match from Olt to Card Swipe system. 
        /// Then we update the rest of the data on the Olt record with what's in the Card swipe system
        /// </summary>
        /// <param name="allInOlt"></param>
        /// <param name="allInCardSwipeSystem"></param>
        private void Update(List<EdmontonPerson> allInOlt, List<EdmontonPerson> allInCardSwipeSystem)
        {
            HashSet<EdmontonPerson> oltPersons = new HashSet<EdmontonPerson>(allInOlt, new EdmontonPersonNameEqualityComparer());
            
            Dictionary<string, EdmontonPerson> swipeCardDictionary = new Dictionary<string, EdmontonPerson>(allInCardSwipeSystem.Count);
            foreach (EdmontonPerson person in allInCardSwipeSystem)
            {
                string key = person.DisplayString;
                if (swipeCardDictionary.ContainsKey(key))
                {
                    logger.Info("Found duplicate key: " + key);
                }
                else
                {
                    swipeCardDictionary.Add(key, person);
                }
            }


            oltPersons.IntersectWith(allInCardSwipeSystem);
            foreach (EdmontonPerson person in oltPersons)
            {
                EdmontonPerson updatedPersonData = swipeCardDictionary[person.DisplayString];
                person.UpdateScanData(updatedPersonData.LastScan, updatedPersonData.ScanStatus);
                edmontonPersonDao.Update(person);
            }
        }

        private IEnumerable<EdmontonPerson> UndoRemove(List<EdmontonPerson> allInSwipeCardSystem, List<EdmontonPerson> deletedInOlt)
        {
            HashSet<EdmontonPerson> inOltToUnDelete = new HashSet<EdmontonPerson>(deletedInOlt, new EdmontonPersonNameEqualityComparer());
            inOltToUnDelete.IntersectWith(allInSwipeCardSystem); // find all deleted items that now appear in the Swipe Card System.
            foreach (EdmontonPerson person in inOltToUnDelete)
            {
                edmontonPersonDao.UndoRemove(person);
            }
            return inOltToUnDelete;
        }

        private void Insert(List<EdmontonPerson> allInCardSwipeSystem, IEnumerable<EdmontonPerson> allInOlt)
        {
            HashSet<EdmontonPerson> inSwipeCardSystemButNotOlt = new HashSet<EdmontonPerson>(allInCardSwipeSystem, new EdmontonPersonNameEqualityComparer());
            inSwipeCardSystemButNotOlt.ExceptWith(allInOlt);
            foreach (EdmontonPerson person in inSwipeCardSystemButNotOlt)
            {
                edmontonPersonDao.Insert(person);
            }
        }
    }

    internal class EdmontonPersonNameEqualityComparer : IEqualityComparer<EdmontonPerson>
    {
        public bool Equals(EdmontonPerson x, EdmontonPerson y)
        {
            return string.Equals(x.DisplayString, y.DisplayString, StringComparison.InvariantCultureIgnoreCase);
        }

        public int GetHashCode(EdmontonPerson obj)
        {
            return obj.FirstName.GetHashCode() + 29 * obj.LastName.GetHashCode() + 2*29* obj.BadgeId.GetHashCode();
        }
    }
}