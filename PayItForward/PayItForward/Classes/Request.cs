using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PayItForward.Classes
{
    public class Request
    {
        #region Constants
        // Used for determining request status
        public const int Approved = 0;
        public const int Pending = 1;
        public const int Denied = 2;

        #endregion

        #region Fields

        [Key]
        private int _requestId;
        private string _type;
        private DateTime _createdTime;
        private DateTime _lastUpdateTime;
        private string _messageInfo;
        private int _status;
        private int _callingId;

        private List<Request> _requests;

        #endregion

        public Request(int callingId)
        {
            CallingId = callingId;
        }

        public Request()
        {

        }

        #region Methods

        #endregion

        #region Properties

        [Key]
        public int RequestId
        {
            get { return _requestId; }
            set { _requestId = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public DateTime CreatedTime
        {
            get { return _createdTime; }
            set { _createdTime = value; }
        }

        public DateTime LastUpdateTime
        {
            get { return _lastUpdateTime; }
            set { _lastUpdateTime = value; }
        }

        public string MessageInfo
        {
            get { return _messageInfo; }
            set { _messageInfo = value; }
        }

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public int CallingId
        {
            get { return _callingId; }
            set { _callingId = value; }
        }

        public List<Request> Requests
        {
            get { return _requests; }
            set { _requests = value; }
        }
        #endregion
    }
}