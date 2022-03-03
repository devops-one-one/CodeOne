pipeline {
  agent any
  triggers {
    pollSCM("* * * * *")
  }
  stages{
    stage("OurFirstStage"){
      steps{
        echo "running"
      }
    }
  }
}