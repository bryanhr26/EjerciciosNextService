//MENSAJE VENTANA
function mostrarAlerta(mensaje) {
    console.log("Mensaje a mostrar en la alerta:", mensaje); // Verifica el mensaje que se pasa

    const result = confirm(mensaje); // Ejecuta confirm()
    console.log("Resultado de confirm():", result); // Muestra si es true o false

    if (result) {
        console.log("Alerta aceptada, invocando función Blazor...");
        // Llamamos directamente al método estático de Blazor
        DotNet.invokeMethodAsync('BlazorApp1', 'ActualizarMensajeOperacion')
            .then(data => {
                console.log("Función de Blazor ejecutada");
            })
            .catch(error => console.error("Error al invocar Blazor:", error));
    } else {
        console.log("El usuario canceló la alerta.");
    }
}

//OFFCANVAS
function CerrarOffcanvas(nombreOffCanvas) {

    var miOffcanvas = document.getElementById(nombreOffCanvas);
    var bsOffCanvas = new bootstrap.Offcanvas(miOffcanvas);
    var miOffCanvasEsVisible = bsOffCanvas._element.classList.contains("show");

    if (miOffCanvasEsVisible) {

        const capasProtectoras = document.querySelectorAll('.offcanvas-backdrop.fade.show');

        if (capasProtectoras != null) {

            capasProtectoras.forEach(capa => {

                if (capa.id) {
                    capa.remove(bsOffCanvas);
                }
            })
        }

        miOffcanvas?.classList.remove('show');
        miOffcanvas?.classList.add('hide');

    }

}

window.abrirOffCanvas = (nombreOffCanvas) => {

    var miOffcanvas = document.getElementById(nombreOffCanvas);
    var bsOffCanvas = new bootstrap.Offcanvas(miOffcanvas);
    var miOffCanvasEsVisible = bsOffCanvas._element.classList.contains("show");

    if (!miOffCanvasEsVisible) {
        bsOffCanvas._backdrop._config.clickCallback = null;
        bsOffCanvas.show();
        const capasProtectoras = document.querySelectorAll('.offcanvas-backdrop.fade.show');

        if (capasProtectoras != null) {

            capasProtectoras.forEach(capa => {

                if (!capa.id) {

                    capa.id = `${nombreOffCanvas}-bs`;

                    return;

                }
            });
        }
    }

};

//AÑADIR MÁS