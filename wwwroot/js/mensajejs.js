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
