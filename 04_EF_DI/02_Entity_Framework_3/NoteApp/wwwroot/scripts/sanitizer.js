/**
 * Converts <html> tags to human readable text so the tags won't be executed by the browser anymore.
 * @param {Array<string>} strings Optional: Strings which should be processed.
 * @returns {Promise<Note>} Returns the concatenated string.
 */
function asText(strings) {
    const [, ...args] = arguments;
    let txt = '';
    strings.forEach((str, idx) => {
        txt += str;
        if (idx < args.length) {
            txt += String(args[idx])
                .replace(/&/g, '&amp;') // encodes & to &amp;
                .replace(/</g, '&lt;')  // encodes < to &lt; 
                .replace(/>/g, '&gt;'); // encodes > to &gt; 
        }
    });
    return txt;
}
