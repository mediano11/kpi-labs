export async function getResource(url) {
    let res = await fetch(url);

    if (!res.ok) {
        throw new Error(`Could not fetch ${url}, status: ${res.status}`);
    }
    return await res.json();
}

export function equalAnswerArrays(a, b) {
    return a.every(el => b.includes(el.value)) && a.length == b.length
}

export function isAtLeastOneChecked(name) {
    let checkboxes = Array.from(document.getElementsByName(name));
    return checkboxes.some(e => e.checked);
}