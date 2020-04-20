$(document).ready(function () {
    $('#radioCom').change(onLicenseTypeChanged);
    $('#radioNonCom').change(onLicenseTypeChanged);
    onLicenseTypeChanged();
});

function onLicenseTypeChanged() {
    // The options for commercial users should only be visible
    // when the commercial license type radio button is checked.
    if (!$('#radioCom').prop('checked')) {
        $('#rowLicensorName').hide();
        $('#rowLicensorEmail').hide();
        $('#rowTurnover').hide();
    } else {
        $('#rowLicensorName').show();
        $('#rowLicensorEmail').show();
        $('#rowTurnover').show();
    }
}