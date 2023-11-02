using System;

namespace Client.Utilities
{
    public class StatusHandler
    {
       
        public static string ConvertStatus(string status)
        {
            var bg = "";
            var st = "";
            switch (status)
            {
                case "Pending":
                    st = "Waiting Manager Approval";
                    bg = "bg-gradient-success";
                    break;
                case "Rejected":
                    st = "Rejected by Manager";
                    bg = "bg-gradient-danger";
                    break;
                case "Accepted":
                    st = "Accepted by Manager";
                    bg = "bg-gradient-success";
                    break;
                case "RejectedHR":
                    st = "Rejected by HR";
                    bg = "bg-gradient-danger";
                    break;
                case "Approved":
                    st = "Approved by HR";
                    bg= "bg-gradient-info";
                    break;
                case "Cancelled":
                    st = "Cancelled by Employee";
                    bg = "bg-gradient-danger";
                    break;
                default:
                    return "Error! Something wrong.";
            }
            return SetHtml(st, bg);
        }
        public static string SetHtml(string status, string bgClass)
        {
            var html = $"<span class='badge badge-sm {bgClass}'>{status}</span>";
            return html;
        }

    }

}
