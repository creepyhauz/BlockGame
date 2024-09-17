#version 330

in vec2 vTextureCoord;
in vec3 vColorMult;

out vec4 outputColor;

uniform sampler2D Texture0;

void main()
{
    outputColor = texture(Texture0, vTextureCoord)*vec4(vColorMult,1);
}