$(document).ready(function () {
    $('#radioCom').change(onLicenseTypeChanged);
    $('#radioNonCom').change(onLicenseTypeChanged);
    $('#Product').change(updateLicense);
    onLicenseTypeChanged();
    updateLicense();
});

function onLicenseTypeChanged() {
    // The options for commercial users should only be visible
    // when the commercial license type radio button is checked.
    if (!$('#radioCom').prop('checked')) {
        $('.commercialInput').each(function () {
            $(this).hide();
        });
    } else {
        $('.commercialInput').each(function () {
            $(this).show();
        });
    }
    updateLicense();
}

function updateLicense() {
    var product = $('#Product').find('option:selected').text();
    var src = '';
    if (product == 'APSIM') {
        if (!$('#radioCom').prop('checked'))
            src = 'APSIM_NonCommercial_RD_licence.htm';
        else {
            src = 'APSIM_Commercial_Licence.htm';
        }
    } else {
        src = 'OtherDisclaimer.html';
    }
    $('td#Terms').html(`<iframe height="300px" width="700px" src="${src}" />`);
    console.log(product);
}