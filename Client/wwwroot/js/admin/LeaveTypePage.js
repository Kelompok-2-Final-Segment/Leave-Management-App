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
        console.log(guid);

        $.ajax({
            url: "/admin/leave/type/delete/" + guid,
            type: 'DELETE'
        })
            .done((data, textStatus, errorThrown) => {
                if (data.code >= 300) {
                    console.log("Error bang");

                    Swal.fire({
                        icon: 'error',
                        title: 'Failed to Delete Leave Type Data',
                        text: 'Oops! Something went wrong while trying to delete leave type data. Please double-check your information.',
                        footer: '<a href="">Why do I have this issue?</a>'
                    });
                }

                if (data.code >= 200 && data.code < 300) {
                    console.log(data);

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
$('#button-create').on('click', () => {
    var leaveTypeData = {
        name: $('#input-name').val(),
        balance: $('#input-balance').val(),
        femaleOnly: $('#select-female-only').val(),
        minDuration: $('#input-min-duration').val(),
        nmaxDuration: $('#input-max-duration').val(),
        remarks: $('#input-remarks').val(),
    }

    let json = JSON.stringify(leaveTypeData);
    //console.log(createAction);
    console.log(json);

    
    $.ajax({
        type: 'POST',
        url: "admin/leave/type/create",
        data: { entity: json },
        dataType: "json",
    })
        .done((data, textStatus, errorThrown) => {
            $('#modal-create').modal('hide');
            console.log(data);
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

/* Employee Data Table */
$("#table-leave-type").DataTable({
    ajax: {
        url: 'https://localhost:7054/admin/leave/type/all',
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

                const detailButton = document.createElement('button');
                detailButton.type = 'submit';
                detailButton.className = 'btn btn-primary';
                detailButton.innerText = 'Edit';

                return `${detailButton.outerHTML} ${deleteButton.outerHTML}`;
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
                'data-bs-target': '#modal-create'
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