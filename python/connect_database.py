from cassandra.cluster import Cluster
from cassandra.auth import PlainTextAuthProvider

cloud_config= {
        'secure_connect_bundle': '../secure-connect-test.zip'
}
auth_provider = PlainTextAuthProvider('datastax', 'datastax')
cluster = Cluster(cloud=cloud_config, auth_provider=auth_provider)
session = cluster.connect()

row = session.execute("select count(*) from system.local").one()
if row:
    print(row[0])
else:
    print("An error occurred.")
