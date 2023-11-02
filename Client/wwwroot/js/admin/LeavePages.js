/* Detail Button Event */
function detailLeave(guid) {
    $.ajax({
        url: '/admin/leave/' + guid,
        method: 'GET'
    })
        .done((data, textStatus, errorThrown) => {
            let result = data.data;
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
            $('#input-leave-status').val(result.leaveStatus);
            $('#input-manager-remark').val(result.remarkManager);
            $('#input-admin-remark').val(result.remarkAdmin);

        });
}

/* Button Edit Leave Type Event */
function editLeaveType(guid) {
    $('#modal-h5-title').text("UPDATE LEAVE TYPE");

    $.ajax({
        url: '/admin/leave-type/' + guid,
        method: 'GET'
    })
        .done((data, textStatus, errorThrown) => {
            let result = data.data;
            $('#input-guid').val(result.guid);
            $('#input-name').val(result.name);
            $('#input-balance').val(result.balance);
            $('#select-female-only').val(result.femaleOnly.toString()).change();
            $('#input-min-duration').val(result.minDuration);
            $('#input-max-duration').val(result.maxDuration);
            $('#input-remarks').val(result.remarks);
        });

    $('#button-save').on('click', () => {
        var leaveTypeData = {
            guid: $('#input-guid').val(),
            name: $('#input-name').val(),
            balance: $('#input-balance').val(),
            femaleOnly: $('#select-female-only').val(),
            minDuration: $('#input-min-duration').val(),
            maxDuration: $('#input-max-duration').val(),
            remarks: $('#input-remarks').val(),
        }

        let json = JSON.stringify(leaveTypeData);

        $.ajax({
            type: 'PUT',
            url: updateAction,
            data: { entity: json },
            dataType: "json",
        })
            .done((data, textStatus, errorThrown) => {
                $('#modal-leave-type').modal('hide');
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
                        timer: 2500
                    });
                }

                $('#table-leave-type').DataTable().ajax.reload();
            });
    });

}

// Setting Up Data Table
$("#table-leave").DataTable({
    ajax: {
        url: getAllAction,
        dataSrc: 'data',
        dataType: 'JSON'
    },
    columns: columnConfig(),
    dom: 'Bfrtip',
    buttons: buttonConfig()
});

// Create column configuration for data table
function columnConfig() {
    return [
        {
            data: "null",
            render: function (data, type, row, meta) {
                return meta.row + meta.settings._iDisplayStart + 1;
            }
        },
        {
            data: null,
            render: function (data, type, row, meta) {
                return simplyDateTime(row.createdDate);
            }
        },
        { data: "fullName" },
        { data: "nik" },
        { data: "leaveName" },
        {
            data: null,
            render: function (data, type, row, meta) {
                return simplyDateTime(row.startDate);
            }
        },
        {
            data: null,
            render: function (data, type, row, meta) {
                return simplyDateTime(row.endDate);
            }
        },
        {
            data: null,
            render: function (data, type, row, meta) {
                return describeLeaveStatus(row.status);
            }
        },
        {
            data: null,
            render: function (data, type, row, meta) {
                const detailButton = document.createElement('button');
                detailButton.type = 'submit';
                detailButton.className = 'btn btn-primary';
                detailButton.innerText = 'Detail';
                detailButton.id = 'button-leave-detail';
                detailButton.setAttribute('onclick', `detailLeave("${ row.guid }")`);
                detailButton.setAttribute('data-bs-toggle', 'modal');
                detailButton.setAttribute('data-bs-target', '#modal-leave-detail');

                return detailButton.outerHTML;
            }
        },

    ];
}

// Export configuration for data table
function buttonConfig() {
    return [
        {
            extend: 'excelHtml5',
            attr: {
                title: 'Save as Excel',
                id: 'excel-btn'
            },
            className: 'btn btn-success',
            exportOptions: {
                columns: ':visible:not(:last-child)'
            }
        },
        {
            extend: 'pdfHtml5',
            attr: {
                title: 'Save as PDF',
                id: 'pdf-btn'
            },
            className: 'btn btn-danger',
            exportOptions: {
                columns: ':visible:not(:last-child)'
            }
        },
        {
            extend: 'colvis',
            attr: {
                title: 'Select Column',
                id: 'colvis-btn'
            },
            className: 'btn btn-secondary'
        }
    ];
}

// Remove data table default class for avoiding conflict with bootstrap styles
document.getElementById('excel-btn').classList.remove('dt-button', 'buttons-pdf', 'buttons-html5');
document.getElementById('pdf-btn').classList.remove('dt-button', 'buttons-pdf', 'buttons-html5');
document.getElementById('colvis-btn').classList.remove('dt-button');