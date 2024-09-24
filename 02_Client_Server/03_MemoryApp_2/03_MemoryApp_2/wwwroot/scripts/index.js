import { getMemoryStats } from './api.js'

setInterval(async () => {
    const stats = await getMemoryStats();
    document.querySelector('#table-data').innerHTML += `
                    <tr>
                        <td>${(new Date()).toLocaleTimeString()}</th>
                        <td>${stats.total}</th>
                        <td>${stats.used}</th>
                        <td>${stats.free}</th>
                    </tr>`;
}, 1000);