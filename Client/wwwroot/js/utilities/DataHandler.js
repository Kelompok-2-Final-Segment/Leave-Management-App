function simplyDate(dateTime) {
    let date = dateTime.slice(0, 10);

    let split = date.split('-');

    return `${split[2]}-${split[1]}-${split[0]}`;
}

function simplyDateTime(dateTime) {
    let date = dateTime.slice(0, 10);
    let time = dateTime.slice(11, 16);

    let split = date.split('-');

    return `${split[2]}-${split[1]}-${split[0]} ${time}`;
}

function describeLeaveStatus(status) {
    switch (status) {
        case "Pending":
            return `<p class="badg e badge-sm bg-gradient-success">Waiting Manager Approval</p>`;
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

function simplyLeaveStatus(status) {
    switch (status) {
        case "Pending":
            return `Waiting Manager Approval`;
        case "Rejected":
            return `Rejected by Manager`;
        case "Accepted":
            return `Accepted by Manager`;
        case "RejectedHR":
            return `Rejected by HR`;
        case "Approved":
            return `Approved by HR`;
        case "Cancelled":
            return `Cancelled by Employee`;
        default:
            return `Something wrong!`;
    }
}

function booleanIcon(boolean) {
    if (boolean == true) {
        return `<i class="fa-solid fa-circle-check fa-2x" style="color: #5e72e4;"></i>`;
    }

    return `<i class="fa-solid fa-circle-xmark fa-2x" style="color: #f5365c;"></i>`;
} 