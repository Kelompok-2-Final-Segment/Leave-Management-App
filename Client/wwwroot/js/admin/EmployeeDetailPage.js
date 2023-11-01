/* Generate Department Option */
$('#button-update').on('click', () => {
    updateEmployee();
});

async function updateEmployee() {
    const result = await Swal.fire({
        title: 'Update Employee Data',
        text: 'Are you sure you want to update this employee\'s data?',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Confirm Update',
        cancelButtonText: 'Cancel',
    });

    if (result.isConfirmed) {
        var updateData = {
            guid: $('#input-guid').val(),
            firstName: $('#input-firstname').val(),
            lastName: $('#input-lastname').val(),
            birthDate: $('#input-birthdate').val(),
            hiringDate: $('#input-hiring-date').val(),
            gender: parseInt($('#select-gender').val()),
            email: $('#input-email').val(),
            phoneNumber: $('#input-phone-number').val(),
            roleName: $('#select-role').val(),
            departmentName: $('#select-department').val(),
        }

        let json = JSON.stringify(updateData);
        console.log(json);

        $.ajax({
            type: 'PUT',
            url: updateAction,
            data: { entity: json },
            dataType: "json",
        })
            .done((data, textStatus, errorThrown) => {
                console.log(data);
                if (data.code >= 300) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Failed to Update Leave Type',
                        text: 'Oops! Something went wrong while trying to update employee data. Please double-check your information.',
                        footer: '<a href="">Why do I have this issue?</a>'
                    });
                }

                if (data.code >= 200 && data.code < 300) {
                    Swal.fire({
                        position: 'top-end',
                        icon: 'success',
                        title: 'Leave Type Updated Successfully',
                        showConfirmButton: false,
                        timer: 2000
                    });
                }

                setTimeout(function () {
                    // Me-reload halaman setelah 3000ms
                    location.reload();
                }, 2100);
            });
    }
}