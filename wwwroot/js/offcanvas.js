function OpenOffcanvas(id) {
    var offcanvasElement = document.getElementById(id);
    offcanvasElement?.classList.add('show');

    // Asegurarte de que el Offcanvas se muestra correctamente usando Bootstrap JS
    var offcanvas = new bootstrap.Offcanvas(offcanvasElement);
    offcanvas.show();
}

function CerrarOffcanvas(id) {
    var offcanvasElement = document.getElementById(id);
    offcanvasElement?.classList.remove('show');
    offcanvasElement?.classList.add('hide');

    // Asegurarte de que el Offcanvas se muestra correctamente usando Bootstrap JS
    var offcanvas = new bootstrap.Offcanvas(offcanvasElement);
    offcanvas.hide();
}