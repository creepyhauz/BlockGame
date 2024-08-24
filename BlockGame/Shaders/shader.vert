#version 330 core

uniform mat4 aTransform;

layout(location = 0) in vec3 aPosition;
layout(location = 1) in vec2 aTextureCoord;
out vec2 vTextureCoord;

void main(void)
{
    
    gl_Position = vec4(aPosition, 1.0f) * aTransform;
    vTextureCoord = aTextureCoord;
}