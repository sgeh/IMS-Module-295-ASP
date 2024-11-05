const detailsView = document.querySelector("#details-view");

async function getCounter() {
    const request = await fetch('/counter');
    const counter = await request.json();
    return counter.current;
}

async function postCounter() {
    const request = await fetch(
        '/counter/up',
        { method: 'POST' });
    return request.ok;
}

async function countUp() {
    const ok = await postCounter();
    if (ok) {
        await renderIndex();
    }
}

async function renderIndex() {
    const current = await getCounter();
    detailsView.innerHTML = `Current count: <strong>${current}</strong>`;
}

document.querySelector('#count-up').addEventListener(
    'click',
    () => countUp())

renderIndex();