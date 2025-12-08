// https://github.com/richtr/NoSleep.js/
const noSleep = new NoSleep();
let running = false;
function noSleepSetup() {
    // Enable wake lock.
    // (must be wrapped in a user input event handler e.g. a mouse or touch handler)

    document.querySelector(".startStop").addEventListener('click', function enableNoSleep() {
        if (!running) {
            noSleep.enable();
        }
        else {
            noSleep.disable();
        }
        running = !running;
    }, false);
}

function noSleepDisable() {
    noSleep.disable();
    running = false;
}

function downloadCSV(filename, csvContent) {
    const blob = new Blob([csvContent], { type: 'text/csv;charset=utf-8;' });
    const link = document.createElement('a');
    const url = URL.createObjectURL(blob);
    
    link.setAttribute('href', url);
    link.setAttribute('download', filename);
    link.style.visibility = 'hidden';
    
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
    
    URL.revokeObjectURL(url);
}

