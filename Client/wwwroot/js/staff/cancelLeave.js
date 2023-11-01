$(document).ready(function () {
    $(".button-leave-cancel").on("click", function () {
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                var dataId = $(this).data("guid");
                console.log("Data ID of the clicked button: " + dataId);
                $.ajax({
                    url: '/leave/edit/' + dataId,
                    method: 'POST',
                    dataType: 'json'
                })
                    .done(() => {
                        Swal.fire(
                            'Cancelled!',
                            'Your leave has been cancelled.',
                            'success'
                        )
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
