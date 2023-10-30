// Function for showing detail leave modal
function showDetailModal(guid) {
    $('#modal-pending-leave').modal('show');
}

// Setting Up Data Table
$("#table-pending-leave").DataTable({
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
        { data: "nik" },
        {
            data: "fullName",
            render: function (data, type, row, meta) {
                return row.firstName + ' ' + row.lastName;
            }
        },
        { data: "gender" },
        { data: "email" },
        { data: "role" },
        { data: "department" },
        {
            data: null,
            render: function (data, type, row, meta) {
                const deleteButton = document.createElement('button');
                deleteButton.type = 'button';
                deleteButton.className = 'btn btn-primary btn-delete-employee';
                deleteButton.innerText = 'SET STATUS';
                deleteButton.setAttribute('onclick', `showDetailModal("${row.guid}")`);

                document.addEventListener('DOMContentLoaded', function () {
                    deleteButton.addEventListener('click', function () {
                        console.log(row.guid);
                    });
                });

                return deleteButton.outerHTML;
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
console.log("testing");