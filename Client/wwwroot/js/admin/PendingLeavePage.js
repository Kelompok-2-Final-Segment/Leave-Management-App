// Setting Up Data Table
$("#table-pending-leave").DataTable({
    ajax: {
        url: '/admin/leave/pending/all',
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
        { data: "status" },
        {
            data: null,
            render: function (data, type, row, meta) {
                const detailButton = document.createElement('button');
                detailButton.type = 'submit';
                detailButton.className = 'btn btn-primary';
                detailButton.innerText = 'Detail';
                detailButton.id = 'button-leave-detail';
                detailButton.setAttribute('onclick', `detailLeave("${row.guid}")`);
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
console.log("testing");