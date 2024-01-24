using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class LogRead : DomainObject
    {
        private readonly long logId;
        private readonly long readByUserId;
        private readonly DateTime time;

        public LogRead(long logId, long readByUserId, DateTime time)
        {
            this.logId = logId;
            this.readByUserId = readByUserId;
            this.time = time;
        }

        public LogRead(Log log, User readByUser, DateTime time)
        {
            readByUserId = readByUser.Id.Value;
            logId = log.Id.Value;
            this.time = time;
        }

        public long ReadByUserId
        {
            get { return readByUserId; }
        }

        public long LogId
        {
            get { return logId; }
        }

        public DateTime Time
        {
            get { return time; }
        }
    }
}