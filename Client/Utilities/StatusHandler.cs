namespace Client.Utilities
{
    public class StatusHandler
    {
        public static string describeLeaveStatus(string status)
        {
            switch (status)
            {
                case "Pending":
                    return "Waiting Manager Approval";
                case "Rejected":
                    return "Rejected by Manager";
                case "Accepted":
                    return "Accepted by Manager";
                case "RejectedHR":
                    return "Rejected by HR";
                case "Approved":
                    return "Approved by HR";
                case "Cancelled":
                    return "Cancelled by Employee";
                default:
                    return "Error! Something wrong.";
            }
        }


        public static string setLeaveStatusBackground(string status)
        {
            switch (status)
            {
                case "Pending":
                    return "bg-gradient-success";
                case "Rejected":
                    return "bg-gradient-danger";
                case "Accepted":
                    return "bg-gradient-success";
                case "RejectedHR":
                    return "bg-gradient-danger";
                case "Approved":
                    return "bg-gradient-info";
                case "Cancelled":
                    return "bg-gradient-danger";
                default:
                    return "bg-gradient-danger";
            }
        }
    }

}
