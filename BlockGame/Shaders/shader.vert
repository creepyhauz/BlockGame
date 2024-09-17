#version 330 core

uniform mat4 aTransform;

layout(location = 0) in vec3 aPosition;
layout(location = 1) in vec2 aTextureCoord;
layout(location = 2) in vec3 aColorMult;

out vec2 vTextureCoord;
out vec3 vColorMult;

void main(void)
{
    
    gl_Position = vec4(aPosition, 1.0f) * aTransform;

    vColorMult = aColorMult;
    vTextureCoord = aTextureCoord;
}