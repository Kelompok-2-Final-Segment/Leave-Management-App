/* Create Button Event */
function createButton() {
    $('#modal-h5-title').text("CREATE LEAVE TYPE");
    $('#button-save').attr('hidden', false);
    $('#button-update').attr('hidden', true);

}

/* Delete Confirmation Dialog */
async function deleteLeaveType(guid) {
    const result = await Swal.fire({
        title: 'Delete Leave Type',
        text: 'Are you sure you want to delete this leave\'s data?',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Delete',
        cancelButtonText: 'Cancel',
    });

    if (result.isConfirmed) {
        $.ajax({
            url: "/admin/leave-type/delete/" + guid,
            type: 'DELETE'
        })
            .done((data, textStatus, errorThrown) => {
                if (data.code >= 300) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Failed to Delete Leave Type Data',
                        text: 'Oops! Something went wrong while trying to delete leave type data. Please double-check your information.',
                        footer: '<a href="">Why do I have this issue?</a>'
                    });
                }

                if (data.code >= 200 && data.code < 300) {
                    Swal.fire({
                        position: 'top-end',
                        icon: 'success',
                        title: 'Leave Type Data Successfully Deleted',
                        showConfirmButton: false,
                        timer: 2500
                    });
                }

                $('#table-leave-type').DataTable().ajax.reload();
            });
    }
}

/* Create Leave Type Event */
$('#button-save').on('click', () => {

    var leaveTypeData = {
        name: $('#input-name').val(),
        balance: $('#input-balance').val(),
        femaleOnly: $('#select-female-only').val(),
        minDuration: $('#input-min-duration').val(),
        maxDuration: $('#input-max-duration').val(),
        remarks: $('#input-remarks').val(),
    }

    let json = JSON.stringify(leaveTypeData);

    $.ajax({
        type: 'POST',
        url: createAction,
        data: { entity: json },
        dataType: "json",
    })
        .done((data, textStatus, errorThrown) => {
            $('#modal-leave-type').modal('hide');
            console.log("Create");
            if (data.code >= 300) {
                Swal.fire({
                    icon: 'error',
                    title: 'Failed to Create Leave Type',
                    text: 'Oops! Something went wrong while trying to create employee data. Please double-check your information.',
                    footer: '<a href="">Why do I have this issue?</a>'
                });
            }

            if (data.code >= 200 && data.code < 300) {
                Swal.fire({
                    position: 'top-end',
                    icon: 'success',
                    title: 'Leave Type Created Successfully',
                    showConfirmButton: false,
                    timer: 2500
                });
            }

            $('#table-leave-type').DataTable().ajax.reload();
        });
});

/* Button Edit Leave Type Event */
function editLeaveType(guid) {
    $('#modal-h5-title').text("UPDATE LEAVE TYPE");
    $('#button-save').attr('hidden', true);
    $('#button-update').attr('hidden', false);

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

    $('#button-update').on('click', () => {
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

                console.log(data);
                console.log("Update");
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
                $('#button-update').attr('id', 'button-save');
            });
    });
}

/* Employee Data Table */
$("#table-leave-type").DataTable({
    ajax: {
        url: 'https://localhost:7054/admin/leave-type/all',
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
            data: null,
            render: function (data, type, row, meta) {
                return meta.row + meta.settings._iDisplayStart + 1;
            }
        },
        { data: "name" },
        { data: "balance" },
        { data: "minDuration" },
        { data: "maxDuration" },
        { data: "femaleOnly" },
        { data: "remarks" },
        {
            data: null,
            render: function (data, type, row, meta) {
                const deleteButton = document.createElement('button');
                deleteButton.type = 'button';
                deleteButton.className = 'btn btn-danger';
                deleteButton.innerText = 'Delete';
                deleteButton.setAttribute('onclick', `deleteLeaveType("${row.guid}")`);

                const editButton = document.createElement('button');
                editButton.type = 'submit';
                editButton.className = 'btn btn-primary';
                editButton.innerText = 'Edit';
                editButton.id = 'button-edit-leave-type';
                editButton.setAttribute('onclick', `editLeaveType("${row.guid}")`);
                editButton.setAttribute('data-bs-toggle', 'modal');
                editButton.setAttribute('data-bs-target', '#modal-leave-type');

                return `${editButton.outerHTML} ${deleteButton.outerHTML}`;
            }
        },

    ];
}

// Export configuration for data table
function buttonConfig() {
    return [
        {
            text: 'Create Type',
            attr: {
                title: 'Copy',
                id: 'create-btn',
                'data-bs-toggle': 'modal',
                'data-bs-target': '#modal-leave-type',
                'onclick': 'createButton()'
            },
            className: 'btn btn-primary',
            action: function (e, dt, node, config) {

            }
        },
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
document.getElementById('create-btn').classList.remove('dt-button', 'buttons-pdf', 'buttons-html5');
document.getElementById('excel-btn').classList.remove('dt-button', 'buttons-pdf', 'buttons-html5');
document.getElementById('pdf-btn').classList.remove('dt-button', 'buttons-pdf', 'buttons-html5');
document.getElementById('colvis-btn').classList.remove('dt-button');

