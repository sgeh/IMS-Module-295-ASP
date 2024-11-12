const logsView = document.querySelector("#logs-view");

async function getLogs() {
    const request = await fetch('/counter/logs');
    return await request.json();
}

async function renderLogs() {
    const allLogs = await getLogs();

    logsView.innerHTML = '';

    for (let log of allLogs) {
        logsView.innerHTML += `
                    <tr>
                        <td>${(new Date(log.date).toLocaleString())}:</th>
                        <td>${log.current}</th>
                    </tr>`;
    }
}

setInterval(() => renderLogs(), 1000);