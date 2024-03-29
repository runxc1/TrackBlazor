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

