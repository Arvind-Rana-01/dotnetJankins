pipeline {
    agent any

    stages {        
      stage('Build') {
            steps {
                // Build the project
                bat 'dotnet build --configuration Release'
            }
        }

        stage('Test') {
            steps {
                // Run unit tests
                bat 'dotnet test --no-build --verbosity normal'
            }
        }

}
