/* Detail Button Event */
function detailLeave(guid) {
    $.ajax({
        url: '/staff/leave/' + guid,
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
            $('#input-leave-status').val(simplyLeaveStatus(result.leaveStatus));
            $('#input-manager-remark').val(result.remarkManager);
            $('#input-admin-remark').val(result.remarkAdmin);

        });
}

$(document).ready(function () {
    console.log(getAllAction);
    console.log("sini");
    // Setting Up Data Table
    $("#tableLeaves").DataTable({
        ajax: {
            url: getAllAction,
            dataSrc: 'data',
            dataType: 'JSON'
        },
        columns: columnConfig(),
        dom: 'Bfrtip',
        buttons: buttonConfig()
    }).done(result => {
        console.log(result)
    }).fail(error => {
        console.log(error)
    });
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
            },
            init: function (dt, node, config) {
                $(node).removeClass('dt-button buttons-excel button-html5');
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
            },
            init: function (dt, node, config) {
                $(node).removeClass('dt-button buttons-pdf button-html5');
            }
        },
        {
            extend: 'colvis',
            attr: {
                title: 'Select Column',
                id: 'colvis-btn'
            },
            className: 'btn btn-secondary',
            init: function (dt, node, config) {
                $(node).removeClass('dt-button buttons-collection button-colvis');
            }
        }
    ];
}

new DataTable('#tableBalance');

// Remove data table default class for avoiding conflict with bootstrap styles
document.getElementById('excel-btn').classList.remove('dt-button', 'buttons-pdf', 'buttons-html5');
document.getElementById('pdf-btn').classList.remove('dt-button', 'buttons-pdf', 'buttons-html5');
document.getElementById('colvis-btn').classList.remove('dt-button');