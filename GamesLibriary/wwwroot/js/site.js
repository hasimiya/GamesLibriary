// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function openDeleteModal(button) {
    const gameId = button.getAttribute('data-game-id');
    const gameName = button.getAttribute('data-game-name');

    document.getElementById('modalGameName').textContent = gameName;
    document.getElementById('modalGameId').value = gameId;

    const modal = new bootstrap.Modal(document.getElementById('deleteModal'));
    modal.show();
}
function openEditModal(button) {
    const game = JSON.parse(button.dataset.game);
    // JSON - это формат обмена данными, который позволяет сериализовать объекты JavaScript в строку и обратно
    // parse - преобразует строку JSON в объект JavaScript
    // button - элемент кнопки, который вызвал модальное окно
    // dataset - объект, содержащий данные из атрибута data-game
    // game - объект, содержащий данные игры

    document.getElementById('edit-id').value = game.ID;
    document.getElementById('edit-name').value = game.Name;
    document.getElementById('edit-description').value = game.Description;
    document.getElementById('edit-imageUrl').value = game.ImageUrl;
    document.getElementById('edit-genre').value = game.Genre;
    document.getElementById('edit-publication').value = game.Publication;

    const modal = new bootstrap.Modal(document.getElementById('editModal'));
    modal.show();
}

function openCreateModal(button) {
    document.getElementById('create-id').value = '';
    document.getElementById('create-name').value = '';
    document.getElementById('create-description').value = '';
    document.getElementById('create-imageUrl').value = '';
    document.getElementById('create-genre').value = '';
    document.getElementById('create-publication').value = '';

    const modal = new bootstrap.Modal(document.getElementById('createModal'));
    modal.show();
}

// function openDeleteModal(button) - функция, которая вызывается при нажатии кнопки "Delete";
// button - элемент кнопки, на которую нажали;
// getAttribute('data-game-id') - получение ID игры из атрибута data - game - id;
// document - объект, представляющий HTML - документ;
// getElementById - метод для получения элемента по его ID;
// textContent - свойство для установки текста элемента;
// value - свойство для установки значения элемента input;
// modal = new bootstrap.Modal - создание нового экземпляра модального окна Bootstrap;
// modal.show() - метод для отображения модального окна;