function OpenOffcanvas(id) {
    var offcanvasElement = document.getElementById(id);
    var offcanvas = new bootstrap.Offcanvas(offcanvasElement);
    offcanvas.show();
}

function CerrarOffcanvas(id) {
    var offcanvasElement = document.getElementById(id);
    var offcanvas = new bootstrap.Offcanvas(offcanvasElement);
    offcanvas.hide();
}