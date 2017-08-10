using SiteServer.CMS.Core;

namespace SiteServer.CMS.StlParser.Cache
{
    public class StarSetting
    {
        private static readonly object LockObject = new object();

        public static object[] GetTotalCountAndPointAverage(int publishmentSystemId, int contentId, string guid)
        {
            lock (LockObject)
            {
                var cacheKey = StlCacheUtils.GetCacheKeyByGuid(guid, nameof(StarSetting),
                    nameof(GetTotalCountAndPointAverage), publishmentSystemId.ToString(), contentId.ToString());
                var retval = StlCacheUtils.GetCache<object[]>(cacheKey);
                if (retval != null) return retval;

                retval = DataProvider.StarSettingDao.GetTotalCountAndPointAverage(publishmentSystemId, contentId);
                StlCacheUtils.SetCache(cacheKey, retval);
                return retval;
            }
        }
    }
}
