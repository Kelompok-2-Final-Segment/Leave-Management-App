function simplyDateTime(dateTime) {
    dateTime = dateTime.slice(0, 10);

    let split = dateTime.split('-');

    return `${split[2]}-${split[1]}-${split[0]}`;
}

function describeLeaveStatus(status) {
    switch (status) {
        case "Pending":
            return `<p class="badge badge-sm bg-gradient-success">Waiting Manager Approval</p>`;
        case "Rejected":
            return `<p class="badge badge-sm bg-gradient-danger">Rejected by Manager</p>`;
        case "Accepted":
            return `<p class="badge badge-sm bg-gradient-success">Accepted by Manager</p>`;
        case "RejectedHR":
            return `<p class="badge badge-sm bg-gradient-danger">Rejected by HR</p>`;
        case "Approved":
            return `<p class="badge badge-sm bg-gradient-info">Approved by HR</p>`;
        case "Cancelled":
            return `<p class="badge badge-sm bg-gradient-danger">Cancelled by Employee</p>`;
        default:
            return `<p class="badge badge-sm bg-gradient-danger">Something wrong!</p>`;
    }
}