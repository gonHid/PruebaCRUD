// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
        async function obtenerClientes() {
            try {
                const response = await fetch('https://localhost:7136/api/ClientAPI');
                const data = await response.json();
                return data;
            } catch (error) {
                console.error('Error al obtener clientes:', error);
                return [];
            }
        }
async function BuscaPorId() {
    let id = document.getElementById("IdClient").value;
    alert(id);
    try {
        const response = await fetch('https://localhost:7136/api/ClientAPI/'+id);
        const cliente = await response.json();
        const tabla = document.getElementById("clientes-table");
        tabla.innerHTML = ""; // Limpiar contenido existente de la tabla
        const fila = document.createElement("tr");

        const idCell = document.createElement("td");
        idCell.textContent = cliente.id;
        fila.appendChild(idCell);

        const nombreCell = document.createElement("td");
        nombreCell.textContent = cliente.firstName;
        fila.appendChild(nombreCell);

        const apellidoCell = document.createElement("td");
        apellidoCell.textContent = cliente.lastName;
        fila.appendChild(apellidoCell);

        const emailCell = document.createElement("td");
        emailCell.textContent = cliente.email;
        fila.appendChild(emailCell);

        const estadoCell = document.createElement("td");
        estadoCell.textContent = cliente.state;
        fila.appendChild(estadoCell);

        tabla.appendChild(fila); 
    } catch (error) {
        console.error('Error al obtener clientes:', error);
        return [];
    }
}
        async function llenarTablaClientes() {
            const tabla = document.getElementById("clientes-table");
            tabla.innerHTML = ""; // Limpiar contenido existente de la tabla

            const clientes = await obtenerClientes();

            clientes.forEach(cliente => {
                const fila = document.createElement("tr");

                const idCell = document.createElement("td");
                idCell.textContent = cliente.id;
                fila.appendChild(idCell);

                const nombreCell = document.createElement("td");
                nombreCell.textContent = cliente.firstName;
                fila.appendChild(nombreCell);

                const apellidoCell = document.createElement("td");
                apellidoCell.textContent = cliente.lastName;
                fila.appendChild(apellidoCell);

                const emailCell = document.createElement("td");
                emailCell.textContent = cliente.email;
                fila.appendChild(emailCell);

                const estadoCell = document.createElement("td");
                estadoCell.textContent = cliente.state;
                fila.appendChild(estadoCell);

                tabla.appendChild(fila); // Agregar fila a la tabla
            });
        }
window.onload = llenarTablaClientes;