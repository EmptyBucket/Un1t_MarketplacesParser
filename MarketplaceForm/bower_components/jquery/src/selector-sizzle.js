define( [
	"./core",
	"../external/sizzle/dist/sizzle"
], function( jQuery, sizzle ) {

jQuery.find = sizzle;
jQuery.expr = sizzle.selectors;
jQuery.expr[ ":" ] = jQuery.expr.pseudos;
jQuery.uniqueSort = jQuery.unique = sizzle.uniqueSort;
jQuery.text = sizzle.getText;
jQuery.isXMLDoc = sizzle.isXML;
jQuery.contains = sizzle.contains;

} );
