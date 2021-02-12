
export function customMouseEvents() {
    const unlocked = 'lock_open';
    const locked = 'lock';
    const _300Pixels = 'width:300px';
    const _85Pixels = 'width:85xp';
    const _margin300Pixels = 'margin-left:300px;';
    const _margin85Pixels = 'margin-left:105xp;';

    var sidebar = document.getElementById('sideNavBar');
    var lockIcon = document.getElementById('lock_icon');
    var mainElement = document.getElementById('mainElement');

    const debounce = (func, wait) => {
        let timeout;
       
        return function executedFunction(...args) {           
            const later = () => {                
                timeout = null;               
                func(...args);
            };            
            clearTimeout(timeout);
            
            timeout = setTimeout(later, wait);
        };
    };

    if (sidebar) {

        sidebar.addEventListener('mouseover', debounce(MouseOverHandler, 100));
        sidebar.addEventListener('mouseleave', debounce(MouseLeaveHandler, 250));
    }
    if (mainElement) {
        mainElement.style = _margin85Pixels;
    }

    function MouseOverHandler() {
        if (lockIcon.innerHTML === unlocked) {
            ReSize(_300Pixels); ///Expand the sidebar           
        }
    }
    function MouseLeaveHandler() {
        if (lockIcon.innerHTML === unlocked) {
            ReSize(_85Pixels); ///Shrink the sidebar                               
        }
    }
    function ReSize(newSize) {
        sidebar.style = newSize;

        if (newSize === _85Pixels) {
            mainElement.style = _margin85Pixels;

            var elements = document.querySelectorAll('.panel-collapse');

            [].forEach.call(elements, (e) => {
                e.classList.add('collapse');

                console.log(e.id + ' element hidden');
            });

            console.log('navbarwrapper' + " collapse all accordians");

        }
        else {
            mainElement.style = _margin300Pixels;
        }
    }    
}