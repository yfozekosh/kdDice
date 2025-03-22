print('init.js started');

let res = [,
	db.getSiblingDB('admin').auth(
	    process.env.MONGO_INITDB_ROOT_USERNAME,
	    process.env.MONGO_INITDB_ROOT_PASSWORD
	),
	db.createUser(
	    {
        	user: "kddiceProcessor",
	        pwd: "example",
        	roles: [
	            {
        	        role: "readWrite",
                	db: "kddice"
	            }
        	]
	    })
]

printjson(res);

db = db.getSiblingDB('kddice');

printjson(db.createCollection("SquareResponses"));

db.SquareResponses.insert([{"a":3}]);
printjson(res);

print('init.js finished');



