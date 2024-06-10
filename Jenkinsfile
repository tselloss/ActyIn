pipeline {
    agent any
     tools{
            
            jdk 'jdk17'
        }
        
        environment {
            
            SCANNER_HOME= tool 'sonar-scanner'
        }
    stages {
        stage('Git Checkout') {
            steps {
                git branch: 'Dev', credentialsId: 'RelationalDatabases', url: 'https://github.com/tselloss/ActyIn'
            }
        }

          stage('OWASP Dependency Check') {
            steps {
                dependencyCheck additionalArguments: ' --scan ./ ', odcInstallation: 'DC'
                    dependencyCheckPublisher pattern: '**/dependency-check-report.xml'
            }
        }
        
        stage('Trivy FS SCan') {
            steps {
                sh "trivy fs ."
            }
        }

         stage('Sonarqube Analysis') {
            steps {
                
                withSonarQubeEnv('sonar'){
                  sh ''' $SCANNER_HOME/bin/sonar-scanner -Dsonar.projectName=actyin \
                    -Dsonar.projectKey=actyin ''' 
               }
                
               
            }
        }
    }
}
