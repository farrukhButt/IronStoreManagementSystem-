using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronStore.Helpers
{
    class StationIdHelper
    {
        // first item is station and the other one is id
        public static List<string> SeperateStationId(string completeId)
        {

            List<string> idList = new List<string>();

            try
            {
                var ids = completeId.Split('_');
                idList.Add(ids[0]);
                idList.Add(ids[1]);
            }
            catch
            {

            }

            return idList;
        }

        public static string StationIdJoined(int stationId, int Id)
        {
            string stationIdJoined = stationId.ToString() + "_" + Id.ToString();
            return stationIdJoined;
        }
    }
}
