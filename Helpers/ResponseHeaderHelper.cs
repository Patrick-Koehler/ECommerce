using ECommerce.Wrapper;

namespace ECommerce.Helpers
{
    public static class ResponseHeaderHelper
    {
        public static void AddRowInfoHeaders(IHeaderDictionary headers, int deleted, int added, int edited)
        {
            headers.Append("X-Rows-Deleted", deleted.ToString());
            headers.Append("X-Rows-Added", added.ToString());
            headers.Append("X-Rows-Edited", edited.ToString());
        }

        public static void AddRowInfoHeaders(IHeaderDictionary headers, RowCounter rowCounter)
        {
            headers.Append("X-Rows-Deleted", rowCounter.DeletedRows.ToString());
            headers.Append("X-Rows-Added", rowCounter.AddedRows.ToString());
            headers.Append("X-Rows-Edited", rowCounter.EditedRows.ToString());
        }
    }
}
