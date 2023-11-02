$(document).ready(function () {
    $(".button-leave-cancel").on("click", function () {
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, Cancel it!'
        }).then((result) => {
            if (result.isConfirmed) {
                var leaveId = $(this).data("leaveguid");
                var employeeId = $(this).data("guid");
                var values =
                {
                    "GuidLeave": leaveId,
                    "GuidEmployee": employeeId
                }
                $.ajax({
                    url: "/leave/edit/" + leaveId,
                    method: 'POST',
                    dataType: 'json'
                })
                    .done((result) => {
                        Swal.fire(
                            'Cancelled!',
                            'Your leave has been cancelled.',
                            'success'
                        )
                        window.location.href = urlaction;
               
                    }).fail((err) => {
                        Swal.fire(
                            'Fail!',
                            'sorry you can try again later',
                            'error'
                        )
                    });


            }
        });
    });
});
