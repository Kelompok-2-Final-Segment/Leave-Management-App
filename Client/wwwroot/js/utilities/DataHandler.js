function simplyDateTime(dateTime) {
    dateTime = dateTime.slice(0, 10);

    let split = dateTime.split('-');

    return `${split[2]}-${split[1]}-${split[0]}`;
}

function describeLeaveStatus(status) {
    switch (status) {
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
    }
}