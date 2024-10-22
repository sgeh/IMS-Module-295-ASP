const detailsView = document.querySelector("#details-view");

async function renderIndex() {
    const pizzas = await getPizza();
    let detailsHtml = '';

    for (let pizza of pizzas) {
        let footer = '';
        if (pizza.description) {
            footer = `<footer>Hinweis: ${pizza.description}</footer>`;
        }
        detailsHtml += `
            <section class="pizza-entry">
                <header><h2>${pizza.name}</h2></header>
                <div>${pizza.ingredients}</div>
                <div>Kosten für die Zutaten: ${pizza.price} CHF</div>
                ${footer}
            </section>`;
    }
    detailsView.innerHTML = detailsHtml;
}

async function getPizza() {
    const request = await fetch('/api/pizza');
    const pizzas = await request.json();
    return pizzas;
}

renderIndex();