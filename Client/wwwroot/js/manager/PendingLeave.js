function detailLeave(guid) {
    $.ajax({
        url: '/admin/leave/' + guid,
        method: 'GET'
    })
        .done((data) => {
            let result = data.data;
            $('#input-guid').val(result.leaveGuid);
            $('#input-nik').val(result.nik);
            $('#input-department').val(result.departmentName);
            $('#input-fullname').val(result.fullName);
            $('#input-phone-number').val(result.phoneNumber);
            $('#input-email').val(result.email);
            $('#input-department').val(result.departmentName);
            $('#input-apply-date').val(simplyDateTime(result.createdDate));
            $('#input-type').val(result.leaveName);
            $('#input-start-date').val(simplyDateTime(result.startDate));
            $('#input-end-date').val(simplyDateTime(result.startDate));
            $('#input-description').val(result.description);
            $('#input-leave-status').val(describeLeaveStatus(result.leaveStatus));
            $('#input-manager-remark').val(result.remarkManager);
            $('#input-admin-remark').val(result.remarkAdmin);

        }).fail((error) => {
            console.log(error)
        });
}

$(document).ready(function () {
    
    $('#modal-leave-detail').click(function () {
        let leaveId = $('#modal-leave-detail').attr("data-leave-id")
        detailLeave(leaveId);    
    });
});




