pipeline {
    agent any

    stages {
        stage('Git Checkout') {
            steps {
                git branch: 'Dev', credentialsId: 'RelationalDatabases', url: 'https://github.com/tselloss/ActyIn'
            }
        }
    }
}
