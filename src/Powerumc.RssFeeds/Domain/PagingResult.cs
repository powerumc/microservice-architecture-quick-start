namespace Powerumc.RssFeeds.Domain
{
    /// <summary>
    /// 페이징 결과 클래스
    /// </summary>
    /// <typeparam name="TDbModel"></typeparam>
    public class PagingResult<TDbModel>
    {
        /// <summary>
        /// 항목 총 개수
        /// </summary>
        public int TotalCount { get; set; }
        
        /// <summary>
        /// 페이징 결과 목록
        /// </summary>
        public TDbModel Results { get; set; }
    }
}