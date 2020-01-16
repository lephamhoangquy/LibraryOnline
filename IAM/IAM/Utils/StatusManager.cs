using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAM.Utils.ResponseStatusHelper;
namespace IAM.Utils
{
    public class StatusManager
    {
        private ResponseStatus[] ListStatus;
        private static StatusManager instance;
        private Dictionary<string, ResponseStatus> StatusMapping;
        private StatusManager()
        {

        }
        public static StatusManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StatusManager();
                    instance.StatusMapping = new Dictionary<string, ResponseStatus>();
                    instance.InitStatus();
                }
                return instance;
            }
        }

        private void InitStatus()
        {
            List<ResponseStatus> Statuses = new List<ResponseStatus>();
            Statuses.Add(new Status200());
            Statuses.Add(new Status400());
            Statuses.Add(new Status401());
            Statuses.Add(new Status403());
            Statuses.Add(new Status500());
            Statuses.Add(new Status404());
            ListStatus = Statuses.ToArray();

            int n = ListStatus.Length;
            for (int i=0;i<n;i++)
            {
                StatusMapping.Add(ListStatus[i].GetStatusName(), ListStatus[i]);
            }

        }

        public string OK
        {
            get
            {
                return ListStatus[0].GetStatusName();
            }
        }


        public string InternalServerError
        {
            get
            {
                return ListStatus[4].GetStatusName();
            }
        } 


        public string NotFound
        {
            get
            {
                return ListStatus[5].GetStatusName();
            }
        }

        public string BadRequest 
        {
            get
            {
                return ListStatus[1].GetStatusName();
            }
        }
        public string Unauthorized
        {
            get
            {
                return ListStatus[2].GetStatusName();
            }
        }
        public string Forbidden
        {
            get
            {
                return ListStatus[3].GetStatusName();
            }
        }


        public int GetStatusCode(string status)
        {
            if (StatusMapping.ContainsKey(status))
            {
                return StatusMapping[status].GetStatusCode();
            }
            return 404;
        }
    }
}
