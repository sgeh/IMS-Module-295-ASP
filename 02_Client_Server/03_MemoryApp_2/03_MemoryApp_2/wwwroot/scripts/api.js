export async function getMemoryStats() {
    const request = await fetch('/api/memory');
    const memoryStats = await request.json();
    return memoryStats;
}
