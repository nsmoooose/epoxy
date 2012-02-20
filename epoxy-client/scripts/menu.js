function menu_register (name, cb) {
	/* TODO improve this function to be able to group all sorts
	   of links together into groups. Build a tree control with
	   expandable items and submenus etc. */
	var nav = $('mainmenu');
	var link = document.createElement ('a');
	link.onclick = cb;
	var text = document.createTextNode (name);
	link.appendChild (text);
	nav.appendChild (link);
}

window.addEvent('domready', function() {
    /* alert('The DOM is ready!'); */
});
