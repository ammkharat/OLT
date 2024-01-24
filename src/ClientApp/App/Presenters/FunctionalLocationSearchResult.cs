using System;
using System.Collections;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class FunctionalLocationSearchResult
    {
        private readonly List<FunctionalLocationDTO> dtos;
        private IEnumerator enumerator;

        public FunctionalLocationSearchResult(List<FunctionalLocationDTO> dtos)
        {
            this.dtos = dtos;
            Reset();
        }

        public bool MoveNext()
        {
            return enumerator.MoveNext();
        }

        public void MoveToOrJustBefore(FunctionalLocation functionalLocation)
        {
            if (IsAlreadyOn(functionalLocation))
            {
                return;
            }

            int index = GetIndexJustAfter(functionalLocation);
            MoveToBefore(index);
        }

        private bool IsAlreadyOn(FunctionalLocation functionalLocation)
        {
            try
            {
                return enumerator != null && Current.Id == functionalLocation.Id;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        private int GetIndexJustAfter(FunctionalLocation functionalLocation)
        {
            for (int i = 0; i < dtos.Count; i++)
            {
                int compareResult = dtos[i].CompareByHierararchy(functionalLocation);
                if (compareResult == 0)
                {
                    if (i + 1 < dtos.Count)
                    {
                        return i + 1;
                    }
                    return -1;
                }
                if (compareResult > 0)
                {
                    return i;
                }
            }

            return -1;
        }

        private void MoveToBefore(int index)
        {
            Reset();
            for (int i = 0; i < index; i++)
            {
                MoveNext();
            }
        }

        public FunctionalLocationDTO Current
        {
            get { return (FunctionalLocationDTO)enumerator.Current; }
        }

        public void Reset()
        {
            enumerator = dtos.ToArray().GetEnumerator();
        }

    }

}
