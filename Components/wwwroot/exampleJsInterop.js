// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

export function showPrompt(message) {
  return prompt(message, 'Type anything here');
}

export function customMouseEvents(sidebarElementId, lockState) {
    const unlocked = 'lock_open';
    const locked = 'lock';

    var sidebar = document.getElementById(sidebarElementId);

    if (sidebar) {

        sidebar.addEventListener('mouseover', debounce(MouseOverHandler, 100));
        sidebar.addEventListener('mouseleave', debounce(MouseLeaveHandler, 250));
    }

    function MouseOverHandler() {
        if (lockState === unlocked) {
            ReSize(_300Pixels); ///Expand the sidebar           
        }
    }
    function MouseLeaveHandler() {
        if (currentLockState === unlocked) {
            ReSize(_85Pixels); ///Shrink the sidebar                               
        }
    }
    function ReSize(newSize) {
        sidebar.style = newSize;

        if (newSize === _85Pixels) {
            $('#navbarwrapper .panel-collapse').collapse('hide');
            console.log('navbarwrapper' + " collapse all accordians");
        }
    }
}

const debounce = (func, wait) => {
    let timeout;

    // This is the function that is returned and will be executed many times
    // We spread (...args) to capture any number of parameters we want to pass
    return function executedFunction(...args) {
        // The callback function to be executed after 
        // the debounce time has elapsed
        const later = () => {
            // null timeout to indicate the debounce ended
            timeout = null;

            // Execute the callback
            func(...args);
        };
        // This will reset the waiting every function execution.
        // This is the step that prevents the function from
        // being executed because it will never reach the 
        // inside of the previous setTimeout  
        clearTimeout(timeout);

        // Restart the debounce waiting period.
        // setTimeout returns a truthy value (it differs in web vs Node)
        timeout = setTimeout(later, wait);
    };
};

const unlocked = 'lock_open';
const locked = 'lock';
const _300Pixels = 'width:300px';
const _85Pixels = 'width:85xp';
var currentLockState = unlocked;

if (sidebar) {

    sidebar.addEventListener('mouseover', debounce(MouseOverHandler, 100));
    sidebar.addEventListener('mouseleave', debounce(MouseLeaveHandler, 250));
}
if (collapseElements) {
    [].forEach.call(collapseElements, (e) => {

        $(e).on('hidden.bs.collapse', () => {
            ArrowDown(e.id);
            console.log(e.id + " fired hidden event");
        });

        $(e).on('shown.bs.collapse', () => {
            ArrowUp(e.id);
            console.log(e.id + " fired shown event");
        });
    });
}
function LockClickedHandler() {

    if (currentLockState === locked) {
        Unlock();
    } else {
        Lock();
    }

    function Lock() {

        currentLockState = locked; ///Update the current lock state
        lockElement.innerHTML = currentLockState; ///Update the icon lock     

        ReSize(_300Pixels); ///Expand the sidebar                
    }
    function Unlock() {
        currentLockState = unlocked; ///Update the current lock state
        lockElement.innerHTML = currentLockState; ///Update the icon lock 
    }
}
function MouseOverHandler() {
    if (currentLockState === unlocked) {
        ReSize(_300Pixels); ///Expand the sidebar           
    }
}
function MouseLeaveHandler() {
    if (currentLockState === unlocked) {
        ReSize(_85Pixels); ///Shrink the sidebar                               
    }
}
function ReSize(newSize) {
    sidebar.style = newSize;

    if (newSize === _85Pixels) {
        $('#navbarwrapper .panel-collapse').collapse('hide');
        console.log('navbarwrapper' + " collapse all accordians");
    }
}        
function clickHandler(id) {

    var collapsableElement = document.getElementById(id);
    var arrowElement = document.getElementById('arrow_' + id);

    if (collapsableElement) {
        if (collapsableElement.classList.contains('show')) {
            CollapseAccordian(collapsableElement, arrowElement);
        } else {
            OpenAccordian(collapsableElement, arrowElement);
        }
    }
}
function CollapseAccordian(element, arrowElement) {
    $(element).collapse('hide');
    console.log(element.id + " close accordian");
}
function OpenAccordian(element, arrowElement) {
    $(element).collapse('show');

    console.log(element.id + " open accordian");
}
function ArrowDown(elementId) {
    const arrowDown = "keyboard_arrow_down";
    var element = document.getElementById('arrow_' + elementId);

    if (element) {
        element.innerHTML = arrowDown;

        console.log(element.id + " arrow down");
    }
}
function ArrowUp(elementId) {
    const arrowUp = "keyboard_arrow_up";
    var element = document.getElementById('arrow_' + elementId);

    if (element) {
        element.innerHTML = arrowUp;

        console.log(element.id + " arrow up");
    }
}