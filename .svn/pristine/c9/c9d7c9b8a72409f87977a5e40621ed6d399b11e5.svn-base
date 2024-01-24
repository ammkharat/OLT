using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Controls
{
    [TestFixture]
    public class LogDetailThreadTreeViewTest
    {
        [Test]
        public void ShouldLoadARootWithASingleChild()
        {
            var treeView = new LogDetailThreadTreeView();

            LogDTO rootDTO = CreateDummyRootLogDTO();
            List<LogDTO> childDTOList = CreateDummyLogDTOListWithOneChild(rootDTO, rootDTO);

            List<IThreadableDTO> threadableList = childDTOList.ConvertAll(o => (IThreadableDTO) o);

            treeView.LoadLogDetailTree(rootDTO, threadableList);

            // 1 parent
            Assert.AreEqual(1, treeView.Nodes.Count);
            Assert.AreEqual("1", treeView.Nodes[0].Name);

            // 1 child
            Assert.AreEqual(1, treeView.Nodes[0].Nodes.Count);
            Assert.AreEqual("2", treeView.Nodes[0].Nodes[0].Name);
        }

        private static LogDTO CreateDummyRootLogDTO()
        {
            return new LogDTO(1, null, null, "ABC-DEF-GHI",
                              false, false, false, false, false, false, DateTimeFixture.DateTimeNow, -4, "a", "b", "c", "Fred", new DateTime(2006, 1, 1), 
                              new DateTime(2006, 1, 1), 1, new Date(2006, 3, 2), new Time(12, 00), new Date(2006, 3, 2), new Time(16, 00), "12D",
                              true, false, DataSource.MANUAL.IdValue,
                              false, 1, null, false, false, null, "all comments", null, null);
        }

        private static List<LogDTO> CreateDummyLogDTOListWithOneChild(LogDTO rootDTO, LogDTO parentDTO)
        {
            var childDTO = new LogDTO(2, rootDTO.Id, parentDTO.Id, "ABC-DEF-GHI",
                                         false, false, false, false, false, false, DateTimeFixture.DateTimeNow, -4, "a", "b", "c", "Fred", new DateTime(2006, 1, 1),
                                         new DateTime(2006, 1, 1), 1, new Date(2006, 3, 2), new Time(12, 00),  new Date(2006, 3, 2), new Time(16, 00),
                                         "12D", true, false,
                                         DataSource.MANUAL.IdValue, false, 1, null, false, false, null, "all comments", null, null);

            var list = new List<LogDTO> {childDTO};

            return list;
        }
    }
}