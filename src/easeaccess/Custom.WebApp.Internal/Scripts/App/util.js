define([], function () {
    return {

        getRestPathFromNode: function (node) {
            /// <param name="node" type="Ext.data.NodeInterface">
            /// </param>
            /// <returns type="String"></returns>
            var raw = node.raw;
            var path = [];
            if (raw.name) {
                path.add(raw.name);
            }
            for (node = node.parentNode; node; node = node.parentNode) {
                raw = node.raw;
                path.add(raw.name);
            }
            path.reverse();
            return path.join('/');
        }
    };
});