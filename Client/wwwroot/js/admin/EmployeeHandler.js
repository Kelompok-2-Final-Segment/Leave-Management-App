async function deleteEmployee(guid) {
    const result = await Swal.fire({
        title: 'Delete Employee Data',
        text: 'Are you sure you want to delete this employee\'s data?',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Delete',
        cancelButtonText: 'Cancel',
    });

    if (result.isConfirmed) {
        console.log(guid);

        $.ajax({
            url: "/admin/employee/delete/" + guid,
            type: 'DELETE'
        })
            .done((data, textStatus, errorThrown) => {
                if (data.code >= 300) {
                    console.log("Error bang");

                    Swal.fire({
                        icon: 'error',
                        title: 'Failed to Delete Employee Data',
                        text: 'Oops! Something went wrong while trying to delete employee data. Please double-check your information.',
                        footer: '<a href="">Why do I have this issue?</a>'
                    });
                }

                if (data.code >= 200 && data.code < 300) {
                    console.log(data);

                    Swal.fire({
                        position: 'top-end',
                        icon: 'success',
                        title: 'Employee Data Successfully Deleted',
                        showConfirmButton: false,
                        timer: 2500
                    });
                }

                $('#table-employee').DataTable().ajax.reload();
            });
    }
}

function detailEmployee(employeeGuid) {
    console.log(employeeGuid);
    $.ajax({
        type: 'POST',
        url: detailAction,
        data: { guid: employeeGuid },
        dataType: "json",
    })
        .done((data, textStatus, errorThrown) => {
            console.log(data); 
        });
    console.log("test");
}
