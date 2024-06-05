// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
async function Guardar() {
    event.preventDefault();
    const form = document.getElementById('cliente-form');

    const nuevoCliente = {
        FirstName: document.getElementById('FirstName').value,
        LastName: document.getElementById('LastName').value,
        Email: document.getElementById('Email').value,
        State: 'Activo'
    };

    try {
        const response = await fetch('https://localhost:7136/api/ClientAPI', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(nuevoCliente)
        });

        if (response.ok) {
            alert('Cliente agregado exitosamente');
            form.reset();
        } else {
            const errorText = await response.text();
            alert('Error al agregar cliente: ' + errorText);
        }
    } catch (error) {
        console.error('Error al enviar datos del cliente:', error);
        alert('Error al enviar datos del cliente. Consulta la consola para más detalles.');
    }
}

async function Actualizar() {
    event.preventDefault(); 

    const form = document.getElementById('cliente-form');
    const id = document.getElementById('Id').value;
    const nuevoCliente = {
        Id: id,
        FirstName: document.getElementById('FirstName').value,
        LastName: document.getElementById('LastName').value,
        Email: document.getElementById('Email').value,
        State: document.getElementById('State').value
    };

    try {
        const response = await fetch('https://localhost:7136/api/ClientAPI/' + id, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(nuevoCliente)
        });

        if (response.ok) {
            alert('Cliente actualizado exitosamente');
            form.reset();
        } else {
            const errorText = await response.text();
            alert('Error al actualizar cliente: ' + errorText);
        }
    } catch (error) {
        console.error('Error al enviar datos del cliente:', error);
        alert('Error al enviar datos del cliente. Consulta la consola para más detalles.');
    }
}