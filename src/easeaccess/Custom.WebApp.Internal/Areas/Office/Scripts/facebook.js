Ext.define('TCApp.store.Facebook', {
    extend: 'Ext.data.Store',
    requires: [
        'App.model.Facebook'
    ],

    config: {
        autoLoad: true,
        model: 'App.model.Facebook',
        storeId: 'Facebook',
        proxy: {
            type: 'jsonp',
            url: 'https://graph.facebook.com/51539791474/feed?access_token=AAACEdEose0cBAAJt7hcZCdkHHK8hOjZBDFd8GSfg2xkI6hj5AghswWn7MvBTz4B4xooN4t2fXvMmTZCrxAq4t5ofnnPIY7oZBebnbuB5wQZDZD',
            reader: {
                type: 'json',
                rootProperty: 'data'
            }
        }
    }
});

Ext.define('App.model.Facebook', {
    extend: 'Ext.data.Model',
    config: {
        fields: [
            {
                name: 'message'
            },
            {
                name: 'picture'
            },
            {
                name: 'link'
            },
            {
                name: 'description'
            }
        ]
    }
});

var itemTpl = '<div class="wholeitem"><img src="{picture}" class="facebookthumb" />{message}</div>';
   // '<div class="smalltext">{description}</div></div>';